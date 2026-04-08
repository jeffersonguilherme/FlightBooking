✈️ Flight Booking API
API REST para venda de passagens aéreas desenvolvida com .NET 8, seguindo os princípios de Clean Architecture, DDD e SOLID.

📌 Sobre o Projeto
Este sistema permite:

Cadastro e autenticação de usuários: Utiliza JWT (JSON Web Tokens) e ASP.NET Identity para gerenciar o acesso.
Pesquisa e gerenciamento de voos: Funcionalidades para buscar e administrar informações de voos.
Criação de reservas (carrinho de viagem): Permite aos usuários criar e gerenciar suas reservas de passagens.
Processamento de pagamento: Integração para processar transações financeiras.
Emissão de bilhetes: Geração e envio de bilhetes de voo.
Backoffice para agentes e administradores: Interface para gerenciamento interno por agentes e administradores.
🏗️ Arquitetura
A estrutura do projeto é baseada em Clean Architecture, promovendo a separação de responsabilidades e a manutenibilidade do código. A organização dos diretórios é a seguinte:

src/
├── FlightBooking.API
├── FlightBooking.Application
├── FlightBooking.Domain
├── FlightBooking.Infrastructure
└── FlightBooking.Tests
Camadas
API: Contém os controladores (Controllers) e as configurações da API.
Application: Responsável pelos casos de uso (Commands e Queries) da aplicação.
Domain: Define as entidades e as regras de negócio essenciais do sistema.
Infrastructure: Gerencia a persistência de dados (Banco de Dados) e a implementação do Identity.
Tests: Inclui os testes unitários para garantir a qualidade e o funcionamento do código.
🛠️ Tecnologias
As principais tecnologias utilizadas no desenvolvimento deste projeto são:

.NET 8
ASP.NET Core
Entity Framework Core
PostgreSQL
ASP.NET Identity
JWT (JSON Web Tokens)
Swagger: Para documentação e teste da API.
xUnit + Moq: Para testes unitários e simulação de dependências.
👥 Tipos de Usuário
O sistema suporta diferentes perfis de usuário, cada um com permissões e funcionalidades específicas:

Customer: Usuários que realizam a compra de passagens aéreas.
Agent: Agentes que gerenciam voos e reservas.
Admin: Administradores responsáveis pelo gerenciamento de usuários e configurações gerais do sistema.
🚀 Como Executar
Para configurar e executar o projeto localmente, siga os passos abaixo:

1️⃣ Clonar o projeto
git clone https://github.com/seuusuario/flight-booking-api.git
cd flight-booking-api
2️⃣ Configurar o banco de dados (PostgreSQL)
Edite o arquivo appsettings.json na pasta FlightBooking.API para configurar a string de conexão com o seu banco de dados PostgreSQL:

"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=FlightBookingDb;Username=postgres;Password=sua_senha"
}
Certifique-se de substituir sua_senha pela senha do seu usuário postgres.

3️⃣ Rodar as migrations
Navegue até o diretório FlightBooking.API e execute o comando para aplicar as migrações do banco de dados:

dotnet ef database update
4️⃣ Executar a aplicação
Ainda no diretório raiz do projeto, execute a aplicação:

dotnet run --project FlightBooking.API
5️⃣ Acessar Swagger
Após a aplicação ser iniciada, você pode acessar a documentação interativa da API via Swagger no seguinte endereço:

https://localhost:5001/swagger
