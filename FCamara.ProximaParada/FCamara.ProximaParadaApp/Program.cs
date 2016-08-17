using FCamara.ProximaParada.Domain.Entities;
using FCamara.ProximaParada.Domain.Factories;
using FCamara.ProximaParada.Domain.Services;
using SimpleInjector;
using System;

namespace FCamara.ProximaParadaApp
{
    class Program
    {
        private static Container _container { get; set; }
        private static AmigoService _amigoService { get; set; }

        public static AmigoService amigoService
        {
            get
            {
                if (_amigoService == null)
                    _amigoService = _container.GetInstance<AmigoService>();

                return _amigoService;
            }
        }

        static void Main(string[] args)
        {
            RegisterIOC();
            MenuPrincipal();
        }
               
        private static void MenuPrincipal()
        {
            Console.WriteLine("Escolha a opção desejada.");
            Console.WriteLine("1 - Adicionar Amigo");
            Console.WriteLine("2 - Visualizar Todos os Amigos");
            Console.WriteLine("3 - Verificar amigo mais próximo");
            Console.WriteLine("4 - Sair");

            QuebraLinhas(2);
            Console.WriteLine("Qual a opção desejada: ");

            string opcao = Console.ReadLine();
            
            switch(opcao)
            {
                case "1":
                    AdicionarAmigo();
                    break;
                case "2":
                    PrintarAmigos();
                    break;
                case "3":
                    PrintarTresProximosAmigos();
                    break;
                case "4":
                    Sair();
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    MenuPrincipal();
                    break;
            }
        }

        private static void Sair()
        {
            Console.Clear();
            Environment.Exit(1);
        }

        private static void AdicionarAmigo()
        {
            Console.WriteLine("Informe o nome do amigo:");
            string nome = Console.ReadLine();
            Console.WriteLine("Informe a latitude:");
            string latitude = Console.ReadLine();
            Console.WriteLine("Informe a longitude:");
            string longitude = Console.ReadLine();

            double _latitude;
            double _longitude;

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome com valor inválido");

            if (!double.TryParse(latitude.Replace('.', ','), out _latitude))
                throw new Exception("Latitude com valor inválido");

            if (!double.TryParse(longitude.Replace('.', ','), out _longitude))
                throw new Exception("Longitude com valor inválido");

            var amigo = AmigoFactory.Create(nome, _latitude, _longitude);

            amigoService.AdicionarAmigo(amigo);
            Console.Clear();
            Console.WriteLine("--> Cadastrado com Sucesso!!");
            QuebraLinhas(1);
            MenuPrincipal();

        }

        private static void PrintarTresProximosAmigos()
        {
            Console.WriteLine("Informe o código do Amigo que você está: ");
            string codigo = Console.ReadLine();

            var amigoQueEstou = amigoService.ObterAmigoQueEstou(Convert.ToInt32(codigo));
            var amigosProximo = amigoService.ObterProximos(amigoQueEstou);

            QuebraLinhas(2);
            Console.Clear();
            Console.WriteLine("Amigo que estou: " + amigoQueEstou.ToString());
            QuebraLinhas(1);
            Console.WriteLine("--INÍCIO DA LISTAGEM DOS 3 AMIGOS MAIS PRÓXIMOS--");

            foreach (var amigo in amigosProximo)
                Console.WriteLine(amigo.ToString());

            Console.WriteLine("--FIM DA LISTAGEM DOS 3 AMIGOS MAIS PRÓXIMOS--");
            QuebraLinhas(2);
            MenuPrincipal();
        }

        private static void PrintarAmigos()
        {
            QuebraLinhas(2);
            Console.Clear();
            Console.WriteLine("--INÍCIO DA LISTAGEM DE TODOS OS AMIGOS--");

            var amigos = amigoService.ObterTodosAmigos();
            foreach (var amigo in amigos)
                Console.WriteLine(amigo.ToString());

            Console.WriteLine("--FIM DA LISTAGEM DE TODOS OS AMIGOS--");
            QuebraLinhas(2);
            MenuPrincipal();
        }

        private static void QuebraLinhas(int linhas)
        {
            for (int i = 0; i < linhas; i++)
                Console.WriteLine("");
        }

        private static void RegisterIOC()
        {
            _container = new Container();
            ProximaParada.IOC.Startup.Bootstrap(_container, Lifestyle.Singleton);
            _container.Verify();
        }
    }
}
