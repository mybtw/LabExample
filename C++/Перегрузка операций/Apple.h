

#ifndef apple
#define apple
#include<iostream>
enum AppleColor { green, yellow, red };

class Apple {
private:
	AppleColor _color;
	double _weight;
public:
	Apple(AppleColor c=green, double w=0.2):_color(c), _weight(w) {}



	double weight() const {
		return this->_weight;
	}
	void color(int n) ;
	
	


	AppleColor color() const {
		return this->_color;
	}

	void weight(double w) ;

	friend std::istream& operator>>(std::istream& is, Apple& a) {
		int n;
		double w;
		is >> n >> w;
		a.color(n);
		a.weight(w);
		return is;
	}
	Apple& operator++()
	{
		if (_color != red)
		 _color = static_cast<AppleColor> (_color + 1);
		return *this;
	}
	Apple operator++(int)
	{
		Apple a = *this;
		++* this;
		return a;
	}
	
};

inline bool operator==(const Apple& a1, const Apple& a2) {
	return(a1.color() == a2.color() && a1.weight() == a2.weight());
}

inline bool operator!=(const Apple& a1, const Apple& a2) {
	return!(a1 == a2);
}


inline bool operator<(const Apple& a1, const Apple& a2) {
	if (a1.weight() == a2.weight())
		return (static_cast<int>(a1.color()) < static_cast<int>(a2.color()));
	else return (a1.weight() < a2.weight());
}
inline bool operator<=(const Apple& a1, const Apple& a2) {
	if (a1 == a2)
		return true;
	else return (a1 < a2);
}



/*header*/
#endif apple
