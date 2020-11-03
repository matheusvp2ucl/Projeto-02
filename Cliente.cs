using System;

class Cliente{

  private string NomeDoCliente;
  private string NascimentoDoCliente;
  private string CpfDoCliente;
  private string EnderecoDoCliente;

  public Cliente( string nome, string nascimento, string cpf, string endereco ){
    NomeDoCliente       = nome;
    NascimentoDoCliente = nascimento;
    CpfDoCliente        = cpf;
    EnderecoDoCliente   = endereco;
  }

  // Get-Set do Nome do Cliente
  public string NomeCliente{
    get{ return NomeDoCliente; }
    set{ NomeDoCliente = value; }
  }

  // Get-Set da Data de Nascimento
  public string NascimentoCliente{
    get{ return NascimentoDoCliente; }
    set{ NascimentoDoCliente = value; }
  }

  // Get-Set do CPF do Cliente
  public string CpfCliente{
    get{ return CpfDoCliente; }
    set{ CpfDoCliente = value; }
  }

  // Get-Set do Endereco do Cliente
  public string EnderecoCliente{
    get{ return EnderecoDoCliente; }
    set{ EnderecoDoCliente = value; }
  }
  

}