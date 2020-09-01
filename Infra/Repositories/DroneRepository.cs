using Dapper;
using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Constants;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public  class DroneStatusResult
    {
        public int Id { get; set; }

        public int Capacidade { get; set; }

        public int Velocidade { get; set; }

        public int Autonomia { get; set; }

        public int Carga { get; set; }

        public float Perfomance { get; set; }

        public int SomaPeso { get; set; }
        public int SomaDistancia { get; set; }
    }

    public class DroneRepository : IDroneRepository
    {
        private readonly DataContext _context;
        private readonly string _connectionString;

        public DroneRepository(DataContext context,
            IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString(ProjectConsts.CONNECTION_STRING_CONFIG);

        }

        public void SaveDrone(Drone drone)
        {
            _context.Drone.Add(drone);
            _context.SaveChangesAsync();
        }

        public Drone RetornaDrone()
        {
            return _context.Drone.FirstOrDefault();
        }

        public List<StatusDroneDto> GetDroneStatusAsync()
        {
            using SqlConnection conexao = new SqlConnection(_connectionString);
            var resultado =  conexao.Query<StatusDroneDto>(GetStatusSqlCommand());
            return resultado.ToList();
        }
        public DroneStatusDto RetornaDroneStatus(int droneId)
        {
            using SqlConnection conexao = new SqlConnection(_connectionString);

            DroneStatusDto droneStatusDto = null;

            var consulta = conexao.Query<DroneStatusResult>(GetSqlCommand(droneId)).FirstOrDefault();

            if (consulta != null)
            {
                droneStatusDto = new DroneStatusDto();

                droneStatusDto.Drone = new Drone();

                droneStatusDto.Drone.Id = consulta.Id;
                droneStatusDto.Drone.Velocidade = consulta.Velocidade;
                droneStatusDto.Drone.Capacidade = consulta.Capacidade;
                droneStatusDto.Drone.Autonomia = consulta.Autonomia;
                droneStatusDto.Drone.Carga = consulta.Carga;
                droneStatusDto.Drone.Perfomance = consulta.Perfomance;
                droneStatusDto.SomaPeso = consulta.SomaPeso;
                droneStatusDto.SomaDistancia = consulta.SomaDistancia;

            }

            return droneStatusDto;
        }

        private string GetSelectPedidos(int situacao, StatusEnvio status)
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine("select a.DroneId,");
            stringBuilder.AppendLine($"{situacao} as Situacao,");
            stringBuilder.AppendLine(" a.Id as PedidoId,");
            stringBuilder.AppendLine(" c.Id as ClienteId,");
            stringBuilder.AppendLine(" c.Nome,");
            stringBuilder.AppendLine(" c.Latitude,");
            stringBuilder.AppendLine(" c.Longitude");
            stringBuilder.AppendLine(" from PedidoDrones a,");
            stringBuilder.AppendLine(" Pedido b,");
            stringBuilder.AppendLine(" Cliente c");
            stringBuilder.AppendLine($" where a.StatusEnvio <> {(int)status}");
            stringBuilder.AppendLine(" and a.DataHoraFinalizacao > dateadd(hour,-3,CURRENT_TIMESTAMP)");
            stringBuilder.AppendLine(" and a.PedidoId = b.ID");
            stringBuilder.AppendLine(" and b.ClienteId = c.Id");

            return stringBuilder.ToString();
        }

        private string GetStatusSqlCommand()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(GetSelectPedidos(0, StatusEnvio.AGUARDANDO));
            stringBuilder.AppendLine(" union");
            stringBuilder.Append(GetSelectPedidos(1, StatusEnvio.EM_TRANSITO));
            stringBuilder.AppendLine(" union");
            stringBuilder.AppendLine(" select b.Id as DroneId,");
            stringBuilder.AppendLine(" 1 as Situacao,");
            stringBuilder.AppendLine(" 0 as PedidoId,");
            stringBuilder.AppendLine(" 0 as ClienteId,");
            stringBuilder.AppendLine(" ' ' as Nome,");
            stringBuilder.AppendLine(" 0 as Latitude,");
            stringBuilder.AppendLine(" 0 as Longitude");
            stringBuilder.AppendLine(" from  Drone b");
            stringBuilder.AppendLine(" where b.Id NOT IN  (");
            stringBuilder.AppendLine(" select a.DroneId");
            stringBuilder.AppendLine(" from PedidoDrones a");
            stringBuilder.AppendLine($" where a.StatusEnvio <> {(int)StatusEnvio.FINALIZADO}");
            stringBuilder.AppendLine(" and a.DataHoraFinalizacao > dateadd(hour,-3,CURRENT_TIMESTAMP)");
            stringBuilder.AppendLine(")");

            return stringBuilder.ToString();
        }

        private static string GetSqlCommand(int droneId)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT D.*,");
            stringBuilder.AppendLine("SUM(P.Peso) AS SomaPeso,");
            stringBuilder.AppendLine("SUM(PD.Distancia) AS SomaDistancia ");
            stringBuilder.AppendLine("FROM dbo.PedidoDrones PD ");
            stringBuilder.AppendLine("JOIN dbo.Drone D");
            stringBuilder.AppendLine("on PD.DroneId = D.Id");
            stringBuilder.AppendLine("JOIN dbo.Pedido P");
            stringBuilder.AppendLine("on PD.PedidoId = P.Id");
            stringBuilder.AppendLine($"WHERE PD.DroneId = {droneId}");
            stringBuilder.AppendLine("GROUP BY D.Id, D.Autonomia, D.Capacidade, D.Carga, D.Perfomance, D.Velocidade");

            return stringBuilder.ToString();
        }

        public Drone GetDrone(int id)
        {
            return _context.Find<Drone>(id);
        }
    }
}
