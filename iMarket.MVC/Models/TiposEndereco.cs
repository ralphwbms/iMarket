using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iMarket.Models
{
    public static class TiposEndereco
    {
        public static string Principal { get; } = "Principal";
        public static string Entrega { get; } = "Entrega";
        public static string Cobranca { get; } = "Cobrança";
    }
}