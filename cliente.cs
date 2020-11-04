using System;

class cliente{

  public string nome{ get; private set; }

  public string endereco{ get; set; }

  public string email{ get; set;}
  
  public void setNome(string n){
    nome = n; 
  }
  
  public void setEndereco(string e){
    endereco = e; 
  }

  public void setEmail(string e){
    email = e; 
  }
}
