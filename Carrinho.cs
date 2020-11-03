using System;
using System.Collections.Generic;

class Carrinho{

  private Cliente Cliente;
  private List<Produtos> ListaCarrinho;
  private string FormaDePagamento;

  public Carrinho( Cliente cliente ){
    Cliente = cliente;
    ListaCarrinho = new List<Produtos>();
  }

  // Get-Set do Objeto do Cliente
  public Cliente ObjCliente{
    get{ return Cliente; }
    set{ Cliente = value; }
  }

  // Get-Set dos Produtos da Loja
  public List<Produtos> CarrinhoItens{
    get{ return ListaCarrinho; }
    set{ ListaCarrinho = value; }
  }

  // Get-Set da Forma de Pagamento
  public String FormaPagamento{
    get{ return FormaDePagamento; }
    set{ FormaDePagamento = value; }
  }

  public void AdicionaItemCarrinho( Produtos prod  ){
    ListaCarrinho.Add( prod );
    this.WriteColorVerde( "\nItem Adicionado com Sucesso !\n" );
  }

  // Funções para Alterar Cores
  public void WriteColorVerde(string variavel) {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(variavel);
    Console.ResetColor();
  }

}