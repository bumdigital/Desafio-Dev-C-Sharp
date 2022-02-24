# Desafio-Dev-C-Sharp

Exame de Programador C#
Objetivo
Desenvolver uma API em C# com .NET Core que simule algumas funcionalidades de um banco digital. Nesta simulação considere que não há necessidade de autenticação.

Desafio
Você deverá garantir que o usuário conseguirá realizar uma movimentação de sua conta corrente para quitar uma dívida.


Documentação:

Obs: Após levantar a aplicação através do IIS Express a API pode ser testada através do Insomnia, Postman ou semelhantes.

DADO QUE eu consuma a API
QUANDO o método "sacar" for chamado o número da conta deve ser fornecido via URL na sequencia do caminho 
https://localhost:44341/contas/sacar/ Ex.: https://localhost:44341/contas/sacar/3 
Nesse exemplo o numero de conta é 3. Após a execução do método tendo fornecido um numero de conta válido
e também um valor válido ENTÃO o saldo da conta no banco de dados diminuirá de acordo 
E o método retornará o saldo atualizado.

DADO QUE eu consuma a API
QUANDO o método "sacar" for chamado e informando o número da conta e um valor maior do que o meu saldo
ENTÃO o método retornará um erro devido o saldo da conta ser suficiente.

DADO QUE eu consuma a API
QUANDO o método "depositar" for chamado o número da conta deve ser fornecido via URL na sequencia do caminho 
https://localhost:44341/contas/depositar/ Ex.: https://localhost:44341/contas/depositar/3 
Nesse exemplo o numero de conta é 3. Após a execução do método tendo fornecido um numero de conta válido
e também um valor válido ENTÃO o saldo da conta no banco de dados será acrecido de acordo 
E o método retornará o saldo atualizado.

DADO QUE eu consuma a API
QUANDO eu chamar o método GET através da URL https://localhost:44341/contas/
informando o número da conta válido através da sequencia dessa URL Ex.: https://localhost:44341/contas/3 (O número de conta é 3)
ENTÃO a query retornará o saldo atualizado.
