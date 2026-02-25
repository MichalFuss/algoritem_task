using System.Linq;

//1
int[] MaxSubArrar(int[] arr)
{
    int totalSum = arr[0], currentSum = arr[0], istart = 0, iend=0,tempistart=0;
    for (int i = 1; i < arr.Length; i++)
    {
      
        if (arr[i]+currentSum < arr[i])
        {
            currentSum = arr[i];
            tempistart = i;
        }
        else
        {
            currentSum += arr[i];
        }
        
            if(currentSum > totalSum)
            {
                totalSum = currentSum;
                istart = tempistart;
                iend = i + 1;
            }
        
    }
    
    return  arr[istart..iend];
}
int[] arr = { 10, 12, -2,20, 4, -60, 44 };
arr = MaxSubArrar(arr);
for (int i = 0; i < arr.Length; i++)
{
    Console.Write(arr[i] + " ");
}
Console.WriteLine();
//2
//we use a hash map to store the store the values as an object of {time,value} and 
//a globalTime veriable to store he last setAll ang a globalValue to store the last setAll value 
//and a globalCounter to increase every operation
//class Value
//{
//    public int time { get; set; }
//    public int value { get; set; }
//}
//class Cache
//{
//    Dictionary<int, Value> dict = new Dictionary<int, Value>();
//    int globalCounter = 0;
//    int globalTime = 0;
//    int globalValue = 0;
//    public void SetAll(int value)
//    {
//        globalCounter++;
//        globalTime = globalCounter;
//        globalValue = value;
//    }
//    public void Set(int key, int value)
//    {
//        if (dict.ContainsKey(key))
//        {
//            globalCounter++;
//            dict[key].time = globalCounter;
//            dict[key].value = value;
//        }
//    }
//    public int Get(int key)
//    {
//        if (dict.ContainsKey(key))
//        {
//            if (dict[key].time > globalTime)
//            {
//                return dict[key].value;
//            }
//            else
//            {
//                return globalValue;
//            }
//        }
//        else
//        {
//            return -1;
//        }
//    }

//}
//3
//We go through the list (after turning it into an array) and check each number to see if 
//it ruins the non-decreasing order. Then we decide if we should keep it as part of our 
//current sequence or if it's better to start a new one from that spot. 
int LongestNonDecreasingSubsequence(LinkedList<int> list)
{
    int[]arr = list.ToArray();
    int[] dp = new int[arr.Length];
    for (int i = 0; i < arr.Length; i++)
    {
        dp[i] = 1;
        for (int j = 0; j < i; j++)
        {
            if (arr[i] >= arr[j])
            {
                dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
        }
    }
    int max=dp.Max();
    return arr.Length - max;
}
LinkedList<int> list = new LinkedList<int>(new int[] { 1,3,2,5,6,7});
Console.WriteLine(LongestNonDecreasingSubsequence(list));
