
# ✈️ Flight Booking API

API REST para venda de passagens aéreas desenvolvida com **.NET 8**, seguindo os princípios de **Clean Architecture**, **DDD** e **SOLID**.

---

## 📌 Sobre o Projeto

Este sistema permite:

- ✅ Cadastro e autenticação de usuários  
  Utiliza **JWT (JSON Web Tokens)** e **ASP.NET Identity** para gerenciar o acesso.

- 🔍 Pesquisa e gerenciamento de voos  
  Funcionalidades para buscar e administrar informações de voos.

- 🛒 Criação de reservas (carrinho de viagem)  
  Permite aos usuários criar e gerenciar suas reservas de passagens.

- 💳 Processamento de pagamento  
  Integração para processar transações financeiras.

- 🎟️ Emissão de bilhetes  
  Geração e envio de bilhetes de voo.

- 🧑‍💼 Backoffice para agentes e administradores  
  Interface para gerenciamento interno.

---

## 🏗️ Arquitetura

A estrutura do projeto é baseada em **Clean Architecture**, promovendo separação de responsabilidades e manutenibilidade.

### 📁 Estrutura de Diretórios

src/
├── FlightBooking.API
├── FlightBooking.Application
├── FlightBooking.Domain
├── FlightBooking.Infrastructure
└── FlightBooking.Tests


### 📚 Camadas

- **API**  
  Contém os Controllers e configurações da API.

- **Application**  
  Responsável pelos casos de uso (**Commands e Queries**).

- **Domain**  
  Define entidades e regras de negócio.

- **Infrastructure**  
  Gerencia banco de dados e implementação do Identity.

- **Tests**  
  Testes unitários para garantir qualidade do código.

---

## 🛠️ Tecnologias

- .NET 8  
- ASP.NET Core  
- Entity Framework Core  
- PostgreSQL  
- ASP.NET Identity  
- JWT (JSON Web Tokens)  
- Swagger (documentação da API)  
- xUnit + Moq (testes unitários)

---

## 👥 Tipos de Usuário

O sistema suporta diferentes perfis:

- **Customer**  
  Usuários que compram passagens.

- **Agent**  
  Gerenciam voos e reservas.

- **Admin**  
  Gerenciam usuários e configurações gerais.

---

## 🚀 Como Executar

### 1️⃣ Clonar o projeto

```bash
git clone https://github.com/seuusuario/flight-booking-api.git
cd flight-booking-api
