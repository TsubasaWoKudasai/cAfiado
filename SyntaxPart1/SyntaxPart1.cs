// salvando os codigos que vi nos primeiros modulos de C# da microsoft

//Console = Classe & Write/WriteLine = Funcao
Console.WriteLine("Imprime uma linha de texto e forca a quebra de linha pra PROXIMA linha");
Console.Write("Similar, porem nao faz a quebra de linha \n");


int numero = 7; // numero inteiro
float numeroFlutuante = 9.11f ; // numero flutuante, especifico pra tal e vai ate os 9 digitos ( aqui TEM que usar o f depois do numero)
double pi = 3.14d; // o double pra voce usar numeros demais que nao passem os 17 digitos 
decimal numeroDecimal = 7.4393m; // numero decimal ( aqui TEM que usar o m depois dos digitos)
string interpolar = "interpolacao"; // string basica, pra frases ou nomes compostos
char character = 'a'; // letra, pra UMA unica unidade de letra
bool verdadeiroOuFalso = true; // o nome da variavel ja diz, mas valor booleano, true ou false
var obvio = "obvio"; // o var funciona entendendo sua variavelem casos OBVIOS, porem ele nao pode ser alterado depois


Console.WriteLine(" exemplo de " + " concatenacao ( cheque o codigo, nao o console )");
// na concatenacao voce pode tb usar o +=, voce por exemplo coloca uma frase numa variavel
// falta uma '' adicao '' entre muitas aspas como por exemplo variavel += "bom dia"
// e entao digita Console.Write(variavel) e ela vai adicionar a string de bom dia 
Console.WriteLine($"exemplo de {interpolar} ( checa o codigo ");

// tem alguns outros tipos de concatenacao que eu achei na documentacao
// vou deixar algumas aqui mas nao cheguei a usar, apenas a ver rapidamente 

// STRING BUILDER
//Em outros casos, você pode combinar cadeias de caracteres em um loop em que você não sabe
//  quantas cadeias de caracteres de origem você está combinando, sendo que o número real de 
//  cadeias de caracteres de origem pode ser grande. A classe StringBuilder foi projetada para
//   esses cenários. O código a seguir usa o método Append da classe StringBuilder para 
//   concatenar cadeias de caracteres.
// Use StringBuilder for concatenation in tight loops.
string sb = new System.Text.StringBuilder();
for (int i = 0; i < 20; i++)
{
    sb.AppendLine(i.ToString());
}
System.Console.WriteLine(sb.ToString());

// STRING.CONCAT OU STRING.JOIN
// Outra opção para unir cadeias de caracteres de uma coleção é usar o método String.Concat.
//  Use método String.Join se um delimitador deve separar cadeias de caracteres de origem. 
//  O código a seguir combina uma matriz de palavras usando os dois métodos:
string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog." };

var unreadablePhrase = string.Concat(words);
System.Console.WriteLine(unreadablePhrase);

var readablePhrase = string.Join(" ", words);
System.Console.WriteLine(readablePhrase);


// LINQ e Enumerable.Aggregate ( serve pra concatencao de array mt bem)
// e pesquisa muito bem dados
// Por fim, você pode usar LINQ e o método Enumerable.Aggregate para 
// unir cadeias de caracteres de uma coleção. Esse método combina as 
// cadeias de caracteres de origem usando uma expressão lambda. A expressão lambda
//  faz o trabalho de adicionar cada cadeia de caracteres ao acúmulo existente. 
//  O exemplo a seguir combina uma matriz de palavras, adicionando um espaço entre cada palavra na matriz:

string[] words = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog." };

string phrase = words.Aggregate((partialPhrase, word) =>$"{partialPhrase} {word}");
System.Console.WriteLine(phrase);
