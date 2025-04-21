#include <iostream>
#include <string>

class VideoDecoder {
public:
	void decodeVideo(const std::string& file) {
		std::cout << "Decoding video stream from " << file << "\n";
	}
};

class AudioDecoder {
public:
	void decodeAudio(const std::string& file) {
		std::cout << "Decoding audio stream from " << file << "\n";
	}
};

class Renderer {
public:
	void renderVideo() {
		std::cout << "Rendering video frames" << "\n";
	}

	void playAudio() {
		std::cout << "Playing audio\n";
	}
};

int main() {
	

	return 0;
}