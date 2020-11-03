using System;
using System.Threading;

class MainClass {
  public static void Main (string[] args) {
    // Codigo Principal
    Console.Clear();
    
    // Instacia a Loja e Carrega a lista de Prdutos a Venda
    Loja mercado = new Loja( "Extrabom" );
    mercado.CarregaListaDeProdutos();

    // Pede as informações do cliente
    Console.Write("Informe seu Nome: ");
    string nomeCliente = Console.ReadLine();

    Console.Write("Informe sua data de Nascimento [xx/xx/xxxx] : ");
    string nascimentoCliente = Console.ReadLine();

    Console.Write("Informe seu CPF: ");
    string cpfCliente = Console.ReadLine();

    Console.Write("Informe seu Endereço: ");
    string enderecoCliente = Console.ReadLine();

    // Instacia o cliente com suas respectivas informações
    Cliente cliente = new Cliente( nomeCliente, nascimentoCliente, cpfCliente, enderecoCliente );

    // Instacio o Carrinho adicionando o Cliente
    Carrinho carrinho = new Carrinho( cliente );

    // Inicia a compra dos produtos do carrinho !
    while( true ){

      mercado.MostraProdutos();

      Console.Write("Informe o codigo do produto: ");
      int codProduto = int.Parse( Console.ReadLine() );

      Console.Write("Informe a quantidade de produto: ");
      double qtdProduto = double.Parse( Console.ReadLine() );

      if( mercado.VerificaEstoque( codProduto, qtdProduto ) ){
        Produtos prod = mercado.PegaProduto( codProduto );
        prod.QuantidadeProduto = qtdProduto;
        carrinho.AdicionaItemCarrinho( prod );
        Thread.Sleep(250);
      }else{
        mercado.AvisoEstoque();
        Thread.Sleep(250);
      }

      Console.WriteLine();

      Console.WriteLine("0 - Finalizar Compra !");
      Console.WriteLine("1 - Continuar Compra !\n");
      Console.Write("Opção: ");
      int compraOK = int.Parse( Console.ReadLine() ) ;

      if( compraOK == 0 ){
        break;
      }

    }

    Console.Clear();

    Console.Write("Informe a forma de Pagamento: ");
    string pagProduto = Console.ReadLine();
    carrinho.FormaPagamento = pagProduto;

    mercado.MostrarCupomNaoFiscal( carrinho );
    
  }
}