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

class MediaPlayer {
private:
	VideoDecoder video;
	AudioDecoder audio;
	Renderer renderer;
public:
	void playMedia(const std::string& filename) {
		std::cout << "[MediaPlayer] Starting playback\n";
		video.decodeVideo(filename);
		audio.decodeAudio(filename);
		renderer.renderVideo();
		renderer.playAudio();
		std::cout << "[MediaPlayer] Playback finished\n";
	}
};

int main() {
	MediaPlayer mediaPlayer;
	mediaPlayer.playMedia("awesome_movie.mp4");

	return 0;
}