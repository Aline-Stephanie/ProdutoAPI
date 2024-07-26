# ProdutoAPI

## Índice
* [Descrição do Projeto](#descrição-do-projeto)
* [Funcionalidades](#funcionalidades)
* [Dependências](#dependências)
* [Scripts](#scripts)

## Descrição do Projeto

  Este projeto consiste na implementação de uma API de produto que persiste os dados em um banco Postgres. 

## Funcionalidades
  Nesta API temos as seguintes funcionalidades abaixo:
1. `Obter todos os produtos`: é obtido um JSON com uma listagem de todos os produtos presentes na tabela _produtos_.
2. `Adicionar um produto`: adiciona um novo produto.
3. `Editar um produto`: edita o produto, ao inserir um _id_ existente.
4. `Obter um produto por id`: é obtido um JSON com o produto que possui o _id_ informado na requisição.
5. `Remover um produto por id`: remove o produto, ao inserir um _id_ existente.
6. `Obter o Dashboard`: é obtido um JSON que agrupa os tipos de produto e retorna a quantidade de produtos daquele tipo e o preço médio. Como na imagem abaixo:
 <img src="https://github.com/user-attachments/assets/492aa646-a2b4-4f00-b8ca-352655544d5a" width="200">

Ao executar a API o Swagger apresenta todas as suas funcionalidades, como na imagem que se segue:
![image](https://github.com/user-attachments/assets/cf1fc75f-a53b-4f04-9f4f-11fc14a50950)

### Autorização
Todas as funcionalidades da API dependem de uma autenticação do usuário, assim, apenas usuários existentes na tabela _clientes_ podem executar as requisições. 

1. Caso o usuário não possua autorização, ao executar uma requisição sua resposta é:

![image](https://github.com/user-attachments/assets/6efb4611-c23f-4e14-948c-b7819b8b9df7)

2. Assim, o usuário precisa clicar em <img src="https://github.com/user-attachments/assets/512d7abb-2849-48a1-bf1a-d305c66ff33c" width="100"> e preencher os dados:

<img src="https://github.com/user-attachments/assets/b08d50cd-cd4f-4cb8-8bb8-3827cae5bfce" width="500">

## Dependências

![image](https://github.com/user-attachments/assets/8f87578e-ab20-4342-832b-900a6b79ec58)

```
<PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.7" />
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.4" />
<PackageReference Include="BCrypt.Net-Next" Version="4.0.3" />
```

## Scripts 
Após a criação da _Database_ nomeada como **ProdutoAPI** foram executados os scripts abaixo:
- Criação da tabela de produtos:
```
Create table produtos ( 
	id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	nome VARCHAR(250),
	tipo INT,
	preco DECIMAL(18,2)
);
```
- Criação da tabela de clientes:
```
Create table clientes ( 
	id BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
	login VARCHAR(250) NOT NULL UNIQUE,
	senha VARCHAR(255) NOT NULL
);
```
- Inserção de cliente para teste:
```
INSERT INTO clientes (login, senha)
  VALUES ('usuarioTeste', '$2a$12$u1E40UgOxlzQ9FJS3g2WGeHGeRAOWIdl5vPe7pV46LUzEm3S1p5u');
```
> Observação:
> Este _hash_ é para a senha "12345".
