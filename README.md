# Receita
Serviço de receita desenvolvido para fins avaliativos visando obtenção do título de Especialista em Arquitetura de Software Distribuídos. Os dados trafegados pela API poderão ser utilizados para insumo de qualquer meio produtivo. 

## Arquitetura

O Back-end concentra o coração da nossa aplicação. Foi desenvolvido um microsserviço responsável pelo domínio de receitas. Foi utilizado um conceito arquitetural chamado *Onion* em conjunto com o padrão *DDD (Domain Driven Design)*, onde destribuímos também dentro do próprio serviço responsabilidades individuais entre cada camada. E dentro da camada de aplicação onde se concentram as regras de negócio e a comuniação entre a camada de apresentação da camada de dados. Isso faz com as responsabilidades fiquem mais desacopladas facilitando também futuras implementações. 

## Tecnologias utilizadas

Todos os serviços são ASP.NET Core Web Application, utilizando versão 3.1. Para a comuniação com o banco de dados da Open API https://www.themealdb.com/api.php foi utilizado o httpclient para a comunicação entre as APIs visto que ela já fornece um vasto banco de dados de receitas.

Testes unitários utilizando xUnit pela sua versatilidade e adaptabilidade com bibliotecas chaves como a *Moq*, facilidade de uso e conhecimento prévio. 

## Como Executar

O serviço está configurado e documentado com o *Swagger*, então está disponível para acesso rodando pelas chamadas diretas nas APIs.

 - Clone o repositório git, descompacte e abra o arquivo .sln (desejavel visual studio 2017 ou superior).
 - Ao carregar a solution, abra o solution explorer no canto direito da tela, nele será exibido todos os projetos da aplicação. Caso já não esteja, clique com o botão direito encima do receita.api e selecione "Set as Startup Project", isso definirá este como o projeto de execução.
 - Feito isso, basta clicar em IIS Express, sinalizado como um botão play verde nas barras de ferramentas. O swagger será carregado, e por ele, pode se realizar as pesquisas de receitas.
