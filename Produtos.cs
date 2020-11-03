using System;
using System.Collections.Generic;

class Produtos{

  private string NomeDoProduto;
  private double ValorDoProduto;
  private double QuantidadeDoProduto;

  public Produtos( string nome, double valor, double quantidade ){
    NomeDoProduto = nome;
    ValorDoProduto = valor;
    QuantidadeDoProduto = quantidade;
  }

  // Get-Set do Nome do Produto
  public string NomeProduto{
    get{ return NomeDoProduto; }
    set{ NomeDoProduto = value; }
  }

  // Get-Set do Valor do Produto
  public double ValorProduto{
    get{ return ValorDoProduto; }
    set{ ValorDoProduto = value; }
  }

  // Get-Set do Estoque do Produto
  public double QuantidadeProduto{
    get{ return QuantidadeDoProduto; }
    set{ QuantidadeDoProduto = value; }
  }

}