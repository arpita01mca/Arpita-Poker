using System;
using System.Collections.Generic;

namespace PokerHand
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] pairs = new string[5];
			int counter = 0;
			String finalStr = null;

			Console.Write("Input 5 cards :\n");
			for (int i = 0; i < 5; i++)
			{
				Console.Write("cards - {0} : ", i);
				pairs[i] = (Console.ReadLine()).ToString();
			}
			
			
			Dictionary<string, int> collectionMap = new Dictionary<string, int>();			
			foreach(var data in pairs)
            {
				int pairCount = 0;
				if (collectionMap.ContainsKey(data))
                {
					pairCount = collectionMap[data];
					pairCount++;
					collectionMap.Remove(data);
					collectionMap.Add(data, pairCount);
                }
				else
                {					
					collectionMap.Add(data, 1);					
				}
            }
			foreach (var item in collectionMap )
			{

				if (counter < item.Value)
				{
					counter = item.Value;
					finalStr = item.Key;
				}
				if (counter == item.Value)
				{
					int rank1 = Convert.ToInt32(getCardValue(item.Key));
					int rank2 = Convert.ToInt32(getCardValue(finalStr));

					if (rank1 > rank2)
					{
						finalStr = item.Key;
					}
				}
			}
			if (counter < 2)
				Console.WriteLine(false);			
			else
				Console.WriteLine(true + " " + finalStr);
				Console.ReadLine();
		}
		public static string getCardValue(string cardName)
		{
			string cardValue = "";
			switch (cardName)
			{
				case ("A"):
					cardValue = "14";
					break;
				case ("K"):
					cardValue = "13";
					break;
				case ("Q"):
					cardValue = "12";
					break;
				case ("J"):
					cardValue = "11";
					break;
				default:
					cardValue = cardName;
					break;
			}
			return cardValue;
		}
	}


	
}
