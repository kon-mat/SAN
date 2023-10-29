package konmat;


import static org.junit.jupiter.api.Assertions.*;

import org.junit.jupiter.api.Test;

class HelloMethodTest {

	@Test
	void test() {
		konmat.App.HelloMethod();
		assertEquals(konmat.App.HelloMethod(), "Hello");
		
	}

}
