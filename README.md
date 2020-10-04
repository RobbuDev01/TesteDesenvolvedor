# Busca CEP

O projeto contempla a busca e inclusão de endereços a partir do CEP digitado.

### Começando

Para executar o projeto será necessário ter o seguinte software:

* [Visual Studio] - Ambiente de desenvolvimento integrado da Microsoft para desenvolvimento de software!

### Conceito

O conceito do software é a busca de endereços a partir do CEP digitado pelo usuário, podendo incluir esses usuários no banco de dados. A tecnologia de busca das informações é via API REST, a partir do serviço https://viacep.com.br/.

### Modelagem de dados

Essas informações de endereço, além de pesquisadas, foram dispostas para serem incluídas em um banco dados SQL. Como são dados básicos, consideramos uma única tabela contendo os campos alocados em tela:

* CEP
* Estado
* Cidade
* Bairro
* Rua

### Estrutura do projeto

Foi utilizada a linguagem C# para codificação, onde os processos de manipulação dos dados foram separados por três visões: model (definição de estrutura), business (regra de negócio) e data (processamento das informações).

### Licença

Não se aplica.

### SE VOCÊ CHEGOU ATÉ AQUI
Muito obrigado pela atenção

SOBRE O AUTOR/ORGANIZADOR
Bruno Ferreira Matias, bruno.matias01@hotmail.com
