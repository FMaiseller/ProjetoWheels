<div align="center">

# Wheels

### Sistema de Gerenciamento para Locadora de Bicicletas

Projeto acadêmico desenvolvido com **ASP.NET Core Razor Pages**, **Entity Framework Core** e **SQL Server**.

![.NET](https://img.shields.io/badge/.NET-9.0-blue)
![C#](https://img.shields.io/badge/C%23-Language-purple)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET-Core-red)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-darkred)
![Status](https://img.shields.io/badge/Status-Acad%C3%AAmico-success)

</div>

---

## Sobre o Projeto

O **Wheels** é um sistema web desenvolvido para auxiliar o gerenciamento de uma locadora de bicicletas.

A aplicação permite o controle completo de clientes, bicicletas, locações e devoluções, além da geração de relatórios e indicadores para acompanhamento do desempenho do negócio.

O principal objetivo é substituir processos manuais por uma solução centralizada, aumentando a organização e reduzindo erros operacionais.

---

## Índice

- [Funcionalidades](#funcionalidades)
- [Telas do Sistema](#telas-do-sistema)
- [Arquitetura](#arquitetura)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Regras de Negócio](#regras-de-negócio)
- [Como Executar](#como-executar)
- [Funcionalidades Implementadas](#funcionalidades-implementadas)
- [Objetivos Acadêmicos](#objetivos-acadêmicos)
- [Autor](#autor)

---

## Funcionalidades

| Módulo | Funcionalidades |
|----------|----------|
| Clientes | Cadastro, consulta, edição e exclusão |
| Bicicletas | Cadastro, edição, exclusão e controle de status |
| Locações | Registro de aluguel e cálculo automático |
| Devoluções | Controle de devoluções e multas por atraso |
| Dashboard | Indicadores e métricas gerais |
| Relatórios | Receita, locações e estatísticas |

---

## Telas do Sistema

### Tela Inicial

![Tela Inicial](images/TelaInicial.png)

### Relatório

![Relatório](images/Relatorio.png)

---

## Arquitetura

```text
ProjetoWheels
│
├── Data
│   ├── AppDbContext.cs
│   ├── DbInitializer.cs
│   └── Migrations
│
├── Models
│   ├── Cliente.cs
│   ├── Bicicleta.cs
│   ├── Locacao.cs
│   └── RelatorioViewModel.cs
│
├── Services
│   ├── DashboardService.cs
│   └── RelatorioService.cs
│
├── Pages
│   ├── Clientes
│   ├── Bicicletas
│   ├── Locacoes
│   ├── Dashboard
│   └── Relatorios
│
├── wwwroot
│
├── Program.cs
└── appsettings.json
```

---

## Tecnologias Utilizadas

### Backend

- C#
- ASP.NET Core Razor Pages
- Entity Framework Core

### Banco de Dados

- SQL Server

### Frontend

- HTML5
- CSS3
- Bootstrap

### Ferramentas

- Visual Studio 2022
- Git
- GitHub

---

## Regras de Negócio

- Uma bicicleta não pode ser alugada quando estiver em manutenção.
- Toda locação deve possuir um cliente associado.
- O valor do aluguel é calculado automaticamente pela quantidade de dias.
- Taxas adicionais são aplicadas em caso de atraso.
- O histórico de locações é mantido permanentemente.

---

## Como Executar

### Pré-requisitos

- .NET 9 SDK
- SQL Server
- Visual Studio 2022

### 1️⃣ Clonar o repositório

```bash
git clone https://github.com/FMaiseller/ProjetoWheels.git
```

### 2️⃣ Entrar na pasta

```bash
cd ProjetoWheels
```

### 3️⃣ Configurar a conexão com o banco

Se necessário, edite o arquivo:

```json
appsettings.json
```

e ajuste a string de conexão para sua instância do SQL Server.

### 4️⃣ Aplicar as migrations

```bash
dotnet ef database update
```

### 5️⃣ Executar o projeto

```bash
dotnet run
```

---

## Funcionalidades Implementadas

- [x] Cadastro de clientes
- [x] Edição de clientes
- [x] Exclusão de clientes
- [x] Cadastro de bicicletas
- [x] Edição de bicicletas
- [x] Exclusão de bicicletas
- [x] Controle de disponibilidade
- [x] Registro de locações
- [x] Registro de devoluções
- [x] Dashboard
- [x] Persistência em banco de dados
- [x] Seed Data para testes

---

## Objetivos Acadêmicos

Este projeto foi desenvolvido com foco no aprendizado de:

- Programação Orientada a Objetos
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Arquitetura em Camadas
- Modelagem UML
- Desenvolvimento Web

---

## Autor

**Felipe Lourenço Maiseller Veiga**

[![GitHub](https://img.shields.io/badge/GitHub-FMaiseller-black?logo=github)](https://github.com/FMaiseller)

---

## Licença

Projeto desenvolvido exclusivamente para fins acadêmicos.

---
