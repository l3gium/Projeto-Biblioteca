UTILIZE O DIAGRAMA DE CLASSES APRESENTADO À SEGUIR PARA DESENVOLVER UMA APLICAÇÃO COM AS OPÇÕES ABAIXO:

|Livro| 
|-|
|- isbn: int|
|- titulo: string|
|- autor: string|
|- editora: string|
|- exemplares: List<Exemplar>|
||
|+ adicionarExemplar(Exemplar exemplar): void|
|+ qtdeExemplares(): int|
|+ qtdeDisponiveis(): int|
|+ qtdeEmprestimos(): int|
|+ percDisponibilidade(): double|

|Exemplar| 
|-|
|- tombo: int|
|- emprestimos: List<Emprestimo>|
||
|+ emprestar(): bool|
|+ devolver(): bool|
|+ disponivel(): bool|
|+ qtdeEmprestimos(): int|

|Emprestimo|
|-|
|- dtEmprestimo: DateTime|
|- dtDevolucao: DateTime|

|Livros|
|-|
|- acervo: List<Livro>|
||
|+ adicionar(Livro livro): void|
|+ pesquisar(Livro livro): Livro|

------------------------------------

O PROJETO DEVERÁ SER DESENVOLVIDO EM C# CONSOLE APPLICATION, OFERECENDO AS SEGUINTES OPÇÕES PARA O USUÁRIO:

||
|-|
|0. Sair|
|1. Adicionar livro|
|2. Pesquisar livro (sintético)*|
|3. Pesquisar livro (analítico)**|
|4. Adicionar exemplar|
|5. Registrar empréstimo|
|6. Registrar devolução|
||

--------------------------------------

* . Informar dos dados básicos do livro com as quantidades: total de exemplares, de exemplares disponíveis, de empréstimos e o respectivo percentual de disponibilidade do título

**. Informando, além dos dados acima, os detalhes dos seus exemplares e respectivos empréstimos
