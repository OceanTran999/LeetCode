#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

void printVec(vector<int>&prices){
    for(auto i : prices)
        cout << i << " ";
}

int maxProfit(vector<int>&prices){
    int maxPro = 0, buyVal = prices[0];
    bool holdingStock = true;

    for(int i = 1; i < prices.size(); i++)
    {
        cout << "First: " << buyVal << " " << prices[i] <<  " " << holdingStock << endl;
        // Because we only hold "at most one share of stock", we will assume the user will buy after selling everyday.
        // Because the sell value must bigger than the buy one, therefore if the current value is bigger than the previous, we will calculate them with maximum profit.
        // Check if holding stock, if not it will be buy value, otherwise will be the sell value
        if(holdingStock || i == prices.size() - 1){
            if(prices[i] > buyVal)
                maxPro += (prices[i] - buyVal);
            holdingStock = false;
        }

        if(!holdingStock){
            buyVal = prices[i];
            holdingStock = true;
        }
        cout << "After: " << buyVal << " " << maxPro << " " << holdingStock << endl << endl;
    }
    return maxPro;
}

int main(){
    vector<int> stock = {7,6,4,3,1};
    int maxProf = maxProfit(stock);
    cout << "Max profit is: " << maxProf;
    return 0;
}