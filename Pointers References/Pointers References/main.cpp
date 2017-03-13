#include <iostream>

using namespace std;

void swap1(int x, int y);
void swap2(int& x, int&y);

int main()
{
	int myScore = 800;
	int dionsScore = 2900;

	cout << "Calling swap1() " << endl;
	swap1(myScore, dionsScore);

	cout << "My score is: " << myScore << endl;
	cout << "Dion's score is: " << dionsScore << endl;

	cout << "Calling swap2() " << endl;
	swap2(myScore, dionsScore);

	cout << "My score is: " << myScore << endl;
	cout << "Dion's score is: " << dionsScore << endl;

	cout << "Press the enter key to exit..." << endl;
	cin.ignore(cin.rdbuf()->in_avail() + 1);

	return 0;
}

void swap1(int x, int y) {

	int temp = x;
	x = y;
	y = temp;
}

void swap2(int& x, int& y) {
	int temp = x;
	x = y;
	y = temp;
}