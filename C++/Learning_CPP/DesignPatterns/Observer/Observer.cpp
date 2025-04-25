#include <iostream>
#include <string>
#include <memory>
#include <vector>

class ISubscriber {
public:
	virtual void update(const std::string& news) = 0;
	virtual ~ISubscriber() = default;
};

class NewsAgency {
	std::vector<ISubscriber*> subscribers;
	std::string latestNews;
public:
	void subscribe(ISubscriber* sub) {
		subscribers.push_back(sub);
	}

	void unsubscribe(ISubscriber* sub) {
		subscribers.erase(std::remove(subscribers.begin(), subscribers.end(), sub), subscribers.end());
	}

	void addNews(const std::string& news) {
		latestNews = news;
		notify();
	}
private:
	void notify() {
		for (auto* sub : subscribers) {
			sub->update(latestNews);
		}
	}
};

class Reader : public ISubscriber {
	std::string name;
public:
	Reader(const std::string& n) : name(n) { }

	void update(const std::string& news) override {
		std::cout << name << " received the new: " << news << "\n";
	}
};

int main() {
	NewsAgency agency;

	Reader nikita("Nikita");
	Reader jeka("Jeka");

	agency.subscribe(&nikita);
	agency.subscribe(&jeka);

	agency.addNews("Tomorrow we'll have elections!");
	agency.addNews("Tomorrow will be sunny");

	agency.unsubscribe(&jeka);

	agency.addNews("Our team has won Olympic Games!");

	/*Output:
	Nikita received the new: Tomorrow we'll have elections!
	Jeka received the new: Tomorrow we'll have elections!
	Nikita received the new: Tomorrow will be sunny
	Jeka received the new: Tomorrow will be sunny
	Nikita received the new: Our team has won Olympic Games!
	*/

	return 0;
}