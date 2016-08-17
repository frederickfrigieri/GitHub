using FCamara.ProximaParada.Domain.Contracts.Repositories;
using FCamara.ProximaParada.Domain.Contracts.Services;
using FCamara.ProximaParada.Domain.Entities;
using FCamara.ProximaParada.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TesteUnitario
{
    [TestClass]
    public class AmigoTeste
    {
        private AmigoEntity amigo1;
        private AmigoEntity amigo2;
        
        private IAmigoService amigoService;

        private Mock<IAmigoRepository> amigoRepository;

        [TestInitialize]
        public void Initialize()
        {
            amigoRepository = new Mock<IAmigoRepository>();
            amigoService = new AmigoService(amigoRepository.Object);

            amigo1 = new AmigoEntity("Fred", 10, 10);
            amigo2 = new AmigoEntity("Felipe", 10, 20);
            
        }

        [TestMethod]
        public void InstanciarumAmigo()
        {
            var amigo3 = new AmigoEntity(string.Empty, 0, 0);

            Assert.Fail();
        }

        [TestMethod]
        public void AdicionarUmNovoAmigo()
        {
            var amigo = amigoService.AdicionarAmigo(amigo1);
            
            Assert.IsNull(amigo);
        }

        [TestMethod]
        public void ObterAmigoQueEstou()
        {
            var amigo = amigoRepository.Setup(x=>x.ObterAmigoQueEstou(2)).Returns(amigo1);

            Assert.IsNotNull(amigo);
        }

        [TestMethod]
        public void ObterTodosAmigos()
        {
            var amigos = amigoService.ObterTodosAmigos();

            Assert.IsNotNull(amigos);
        }
    }
}
