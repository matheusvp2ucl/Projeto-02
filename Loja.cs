using System;
using System.IO;
using System.Globalization;
using System.Threading;
using System.Collections.Generic;

class Loja{
  
  private string NomeDaLoja;
  private List<Produtos> ListaDeProdutos;

  // Construtor da Loja
  public Loja( string nome ){
    NomeDaLoja = nome;
  }

  // Get-Set do Nome da Loja
  public string NomeLoja{
    get{ return NomeDaLoja; }
    set{ NomeDaLoja = value; }
  }

  // Get-Set dos Produtos da Loja
  public List<Produtos> Produtos{
    get{ return ListaDeProdutos; }
    set{ ListaDeProdutos = value; }
  }

  public void CarregaListaDeProdutos(){
    // Função para carregar a lista de produtos do CSV / Banco
    ListaDeProdutos = new List<Produtos>();
    StreamReader reader = new StreamReader(@"./ListaDeProdutos.csv", true);
    while ( !reader.EndOfStream ) {
        var valor = reader.ReadLine().Split(';');
        string nome = valor[0].ToUpper();
        double valorProd = double.Parse( valor[1] );
        double quantidade = double.Parse( valor[2] );
        ListaDeProdutos.Add( new Produtos( nome, valorProd, quantidade ) );
    }
  }

  public void SalvaListaDeProdutos(){
    // Função para atualizar a lista de produtos do CSV / Banco
  }

  public void MostraProdutos(){
    Console.Clear();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("                PRODUTOS");
    Console.WriteLine("----------------------------------------");
    for( int i = 0 ; i < ListaDeProdutos.Count ; i++ ){
      Console.Write("[ ");
      this.WriteColorMagenta( i.ToString() );
      Console.Write(" ] - [ ");
      this.WriteColorAmarelo( ListaDeProdutos[i].NomeProduto );
      Console.Write(" ] - [ ");
      this.WriteColorVerde( ListaDeProdutos[i].ValorProduto.ToString() );
      this.WriteColorBlue( " $" );
      Console.WriteLine(" ]");
    }
    Console.WriteLine("----------------------------------------");
    Console.WriteLine();
  }

  public void Carregamento(string strBase){
    Console.Clear();
    for( int x=0; x<2; x++ ){
      Thread.Sleep(500);
      string loadBase = " ";
      for( int i=0; i<4; i++ ){
        Console.Clear();
        this.WriteColorAmarelo( strBase );
        this.WriteColorVerde( loadBase );
        loadBase += ".";
        Thread.Sleep(500);
      }
    }
  }

  public void MostrarCupomNaoFiscal( Carrinho carrinho ){
    this.Carregamento("Gerando Cupom");
    Console.Clear();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("                CLIENTE");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("Nome: {0}", carrinho.ObjCliente.NomeCliente);
    Console.WriteLine("CPF : {0}", carrinho.ObjCliente.CpfCliente);
    Console.WriteLine("Data: {0}", carrinho.ObjCliente.NascimentoCliente);  
    Console.WriteLine("Endereço: {0}", carrinho.ObjCliente.EnderecoCliente);
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("                PRODUTOS");
    Console.WriteLine("----------------------------------------");
    double totalCompra = 0;
    string vendaPagamento = carrinho.FormaPagamento;
    for( int i=0 ; i < carrinho.CarrinhoItens.Count ; i++ ){
      string prodNome  = carrinho.CarrinhoItens[i].NomeProduto;
      double prodValor = carrinho.CarrinhoItens[i].ValorProduto;
      double prodQtd   = carrinho.CarrinhoItens[i].QuantidadeProduto;
      double conta     =  prodValor * prodQtd ;
      totalCompra += conta;
      Console.WriteLine($"{prodNome,-30}{prodQtd, 10}");
      Console.WriteLine($"{prodValor,-30}{conta, 9}$");
    }
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("                TOTAL");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"{"Total:",-30}{totalCompra, 9}$");
    Console.WriteLine($"{"Pagamento:",-15}{ vendaPagamento, 25}");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"{NomeDaLoja, 24}");
    Console.WriteLine("       Obrigado pela Preferencia !");
    Console.WriteLine("----------------------------------------");

  }

  public void AtualizaEstoque( Carrinho carrinho ){
    // Função para atualizar o estoque da lista de Produtos
    this.Carregamento("Atualizando Estoque");
    List<Produtos> CarroCompras = carrinho.CarrinhoItens;
    foreach( Produtos compra in CarroCompras  ){
      foreach( Produtos prod in ListaDeProdutos ){
        if( compra.NomeProduto == prod.NomeProduto ){
          prod.QuantidadeProduto = prod.QuantidadeProduto - compra.QuantidadeProduto;
        }
      }
    }
  }
  
  public bool VerificaEstoque( int posi, double quantidade ){
    double calc = ListaDeProdutos[posi].QuantidadeProduto - quantidade;
    if( calc >= 0 ){
      return true;
    }
    return false;
  }

  public Produtos PegaProduto(int posi){
    return ListaDeProdutos[posi];
  }

  public void AvisoEstoque(){
    this.WriteColorAmarelo("\nNão possui essa quantidade em estoque !\n");
  }

  // Funções para Alterar Cores
  public void WriteColorMagenta(string variavel) {
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Write(variavel);
    Console.ResetColor();
  } 
  public void WriteColorVerde(string variavel) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(variavel);
    Console.ResetColor();
  }
  public void WriteColorAmarelo(string variavel) {
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write(variavel);
    Console.ResetColor();
  }
  public void WriteColorBlue(string variavel) {
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write(variavel);
    Console.ResetColor();
  }
  
}
