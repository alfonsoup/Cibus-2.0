﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CibusMVC.DAL;
using CibusMVC.Models;

namespace CibusMVC.ViewModels
{
    public class DetallePedidoViewModel
    {
        public List<Algo> AlgoAll { get; set; }
        public List<PedidoId> PedidosAll { get; set; }
      
    }
}