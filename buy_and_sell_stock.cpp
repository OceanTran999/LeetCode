#include <iostream>
#include <vector>
#include <algorithm>
using namespace std;

void printVec(vector<int>&prices){
    for(auto i : prices)
        cout << i << " ";
}

int maxProfit(vector<int>&prices){
    int maxPro = 0;
    int buyVal = prices[0];
    for(auto& sellVal : prices)
    {
        // Finding the minimum value of each day to make it as buy value.
        buyVal = min(sellVal, buyVal);

        maxPro = max(maxPro, sellVal - buyVal);
    }
    return maxPro;
}

int main(){
    vector<int> stock = {7,1,5,3,6,4};
    int maxProf = maxProfit(stock);
    cout << "Max profit is: " << maxProf;
    return 0;
}