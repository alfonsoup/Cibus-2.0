using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public interface IDetallePedidoRepository : IDisposable
    {
        IEnumerable<DetallePedido> GetDetallePedidos();
        DetallePedido GetDetallePedidoByID(int detallePedidoId);
        void InsertDetallePedido(DetallePedido detallePedido);
        void DeleteDetallePedido(int detallePedidoID);
        void UpdateDetallePedido(DetallePedido detallePedido);
        IEnumerable<DetallePedido> GetTodosDetallesPedidosByIdPedido(int idPedido);
        void Save();
    }
}