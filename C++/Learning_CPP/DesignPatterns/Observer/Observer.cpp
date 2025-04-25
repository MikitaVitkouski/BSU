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

	void AddNews(const std::string& news) {
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

int main() {


	return 0;
}