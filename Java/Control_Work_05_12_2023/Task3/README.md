Two streams are given — the producer and the consumer. The manufacturer generates some data:integers, floating point, numbers, strings, serialized\deserialized POJO.
The consumer "consumes" them.
The two streams share a common data buffer, the size of which is limited. If the buffer is empty, the consumer must wait for the data to appear there. If the buffer is full, the producer must wait until the consumer takes the data and the space is free.
