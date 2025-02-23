# Agenda de Contatos MVC

## 📌 Sobre o Projeto

Este projeto é um sistema de gerenciamento de usuários desenvolvido em **ASP.NET Core MVC**, com autenticação e listagem de usuários.

## 🚀 Tecnologias Utilizadas

- **.NET 9**
- **Entity Framework Core**
- **SQL Server** (rodando em container Docker)
- **ASP.NET Core MVC**
- **C#**

## 📂 Estrutura do Projeto

```
📦 AgendaDeContatosMVC
 ┣ 📂 Controllers
 ┃ ┣ 📜 UsuariosController.cs
 ┃ ┗ 📜 AutenticacoesController.cs
 ┣ 📂 Models
 ┃ ┣ 📜 Usuarios.cs
 ┃ ┗ 📜 Autenticacoes.cs
 ┣ 📂 Views
 ┃ ┣ 📂 Usuarios
 ┃ ┃ ┗ 📜 UserList.cshtml
 ┣ 📜 appsettings.json
 ┣ 📜 Program.cs
 ┗ 📜 Startup.cs
```

## 🔧 Configuração e Execução

### 1️⃣ **Clone o repositório**

```sh
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

### 2️⃣ **Configure a conexão com o banco de dados**

No arquivo `appsettings.json`, configure a string de conexão com o SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=AgendaDB;User Id=sa;Password=SuaSenha"
}
```

### 3️⃣ **Rode as migrações do banco de dados**

```sh
dotnet ef database update
```

### 4️⃣ **Execute o projeto**

```sh
dotnet run
```

O sistema estará disponível em `http://localhost:5000`

## 📌 Rotas Principais

| Método | Rota               | Descrição                   |
| ------ | ------------------ | --------------------------- |
| `POST` | `/Login`           | Autentica o usuário         |
| `GET`  | `/UserList/{code}` | Lista usuários autenticados |

## 🛠 Melhorias Futuras

- 📌 Implementar JWT para autenticação
- 📌 Criar interface frontend com React ou Vue.js
- 📌 Melhorar o design das páginas com Bootstrap

---

**Desenvolvido por ****[Rangel Monteiro](https://github.com/RangelMonteiro)** 🚀

Rangel Monteiro Dev

