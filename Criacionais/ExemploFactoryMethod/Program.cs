// A classe abaixo declara o metodo FACTORY que deve retornar um OBJETO de uma classe PRODUTO.
// As subclasses da classe CRIADORA geralmente recebem as implementações dos Metodos
abstract class Creator
{
    //Importante: A classe CRIADORA também pode prover implementações DEFAULT do metodo FACTORY.
    public abstract IProduct FactoryMethod();

    /*
     Apesar do seu nome, a classe CRIADORA não tem como função criar produtos. Geralmente, essa classe
    possui logica de negocio que dependem do objeto de PRODUTO, que é retornado pelo metodo FACTORY.
    As subclasses podem mudar de forma indireta a logica de negocio sobrepoe o metodo FACTORY e retornando
    um tipo diferente de produto.
     */

    public string SomeOperation()
    {
        //Cria um Objeto de PRODUTO
        var product = FactoryMethod();

        //Utilizando o Objeto de PRODUTO
        var result = "Creator: O Mesmo metodo de Criação funcionou com " + product.Operation;

        return result;
    }

}

//Classes de implementação concretas, sobrepoem o metodo FACTORY para poder
//Alterar o tipo de produto retornado
class CreatorConcretaUm : Creator
{
    //Nota-se que aqui a assinatura do metodo ainda é ABSTRATA, mesmo após o classe de implementação concreta
    //é retornada do metodo. Desta forma a classe de criação fica independente da classe de implementação concreta.
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct1();
    }
}

class CreatorConcretaDois : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProduct2();
    }
}

//A interface de produto, declara quais implementações que as classes concretas precisam ter.
public interface IProduct
{
    string Operation();
}

//Classes concretas implementam varias versões da interface de PRODUTO.
class ConcreteProduct1 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct1}";
    }
}

class ConcreteProduct2 : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProduct2}";
    }
}

//Metodo Main
class Client
{
    public void Main()
    {
        Console.WriteLine("App: Deu Start com o creator ConcreteCreator1. ");
        ClientCode(new CreatorConcretaUm());

        Console.WriteLine("");

        Console.WriteLine("App: Deu Start com o creator ConcreteCreator2. ");
        ClientCode(new CreatorConcretaDois());
    }

    //Este metodo serve como uma ponte entre a interface e a classe concreta
    //Desde que a classe cliente fale com a classe criadora usando a interface base
    //E possivel passar qualquer subclasse para este metodo.
    public void ClientCode(Creator creator)
    {
        Console.WriteLine("Client: Nao sei qual é a classe criadora," +
                "Mas mesmo assim funciona! \n" + creator.SomeOperation());
    }
}

class Program
{
    static void Main(string[] args)
    {
        new Client().Main();
    }
}
    