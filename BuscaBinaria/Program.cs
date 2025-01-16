namespace BuscaBinaria;

class Program
{
    private static void Main()
    {
        int[] numbers =
        [
            1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15
        ];
        
        Console.WriteLine("Digite o valor que deseja encontrar: ");

        if (int.TryParse(Console.ReadLine(), out int number))
            throw new ArgumentOutOfRangeException(nameof(number), "Valor inválido informado.");
        
        var binarySearchResponse = GetIndexOfNumberBinarySearch(number, numbers);
        var linearSearchResponse = GetIndexOfNumberLinearSearch(number, numbers);
        
        Console.WriteLine($"BINARY SEARCH -> Index: {binarySearchResponse.Index} encontrado em {binarySearchResponse.Steps} etapas.");
        Console.WriteLine($"LINEAR SEARCH -> Index: {linearSearchResponse.Index} encontrado em {linearSearchResponse.Steps} etapas.");
    }

    /// <summary>
    /// Este algoritmo usa o tempo de execução O(log₂(n))
    /// </summary>
    /// <param name="number">Número para buscar dentro do array</param>
    /// <param name="searchList">Lista para busca</param>
    /// <returns>Uma tupla (Qtd de etapas para encontrar o número, Index do número (caso não encontre, -1))</returns>
    private static (int Steps, int Index) GetIndexOfNumberBinarySearch(int number, int[] searchList)
    {
        int low=0, steps=0, middle, value;
        
        int high = searchList.Length - 1;
        
        while (low <= high)
        {
            steps++;
            
            middle = low + (high - low) / 2;
            
            value = searchList[middle];

            if (number == value)
                return (steps, middle);
            
            if (number < value)
            {
                high = middle - 1;
                continue;
            }

            if (number > value) 
                low = middle + 1;
        }
        
        return (steps, -1);
    }

    /// <summary>
    /// Este algoritmo usa o tempo de execução O(n)
    /// </summary>
    /// <param name="number">Número para buscar dentro do array</param>
    /// <param name="searchList">Lista para busca</param>
    /// <returns>Uma tupla (Qtd de etapas para encontrar o número, Index do número (caso não encontre, -1))</returns>
    private static (int Steps, int Index) GetIndexOfNumberLinearSearch(int number, int[] searchList)
    {
        int steps = 0;
        int index = -1;
        
        for (int i = 0; i < searchList.Length; i++)
        {
            steps++;
            
            if (searchList[i] != number) 
                continue;
            
            index = i;
            break;
        }
        
        return (steps, index);
    }
} 