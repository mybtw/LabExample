#include"Apple.h"
#include<stdexcept>

void Apple::weight(double w)  {

	if (w > 0)
		_weight= w;
	else throw std::invalid_argument("Incorrect weight");
}

void Apple::color(int n)  {
	if (n < 0 || n>2)
		throw std::invalid_argument("Incorrect weight");
	else  _color=  static_cast<AppleColor>(n);
}