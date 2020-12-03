using BlueModas.Web.Bll;
using BlueModas.Web.Bll.Interface;
using BlueModas.Web.Dal.Interface;
using BlueModas.Web.Info.Entities;
using Moq;
using NUnit.Framework;
using System;

namespace BlueModas.Web.Test
{
    public  class SaleTest
    {
        private ISaleBll _saleBll;
        private Mock<ISaleDal> _saleDal;

        [SetUp]
        public void SetUp()
        {
            _saleDal = new Mock<ISaleDal>();
            _saleBll = new SaleBll(_saleDal.Object);
        }
        
        [Test]
        public void AdicionarVendas()
        {
            var sale = new SaleInfo()
            {
                SaleId = Guid.NewGuid(),
                ProductId = Guid.NewGuid(),
                NumberOrder = 488458414
            };

            _saleDal.Setup(x => x.AddSaleAsync(It.IsAny<SaleInfo>())).ReturnsAsync(sale);

            var result = _saleBll.AddSaleAsync(sale);

            Assert.IsNotNull(result);
        }
    }
}
