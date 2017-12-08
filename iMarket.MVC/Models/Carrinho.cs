using System;
using System.Collections.Generic;
using System.Linq;

namespace iMarket.Models
{
    public class Carrinho
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        private const decimal valorMinimoFrete = 10.0M;

        public void AddItem(Produto produto, int quantidade)
        {
            CartLine line = lineCollection
                .Where(p => p.Produto.Id == produto.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                line.Quantidade += quantidade;
            }
        }

        public void RemoveLine(Produto product)
        {
            lineCollection.RemoveAll(l => l.Produto.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        public decimal ComputeTotalValuePlusShippingCost()
        {
            return ComputeTotalValue() + ShippingCost();
        }

        public decimal ShippingCost()
        {
            var valorTotalCompra = ComputeTotalValue();

            if (valorTotalCompra == 0)
                return 0M;

            var valorFrete = Math.Round(valorTotalCompra * 0.1M, 2);

            if (valorFrete < valorMinimoFrete)
                return valorMinimoFrete;
            else
                return valorFrete;
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}