/*
 * Created by SharpDevelop.
 * User: hugoyu
 * Date: 2018/6/11
 * Time: 19:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace BitHack
{
	class Program
	{
		static int multiply_2_power_n(int val, int n)
		{
			// val * (2 power n)
			return val << n;
		}
		
		static int divide_2_power_n(int val, int n)
		{
			// val / (2 power n)
		    return val >> n;
		}
		
		static int get_bit(int val, int n)
		{
			// get val's n-th bit
			return val & (1 << n);
		}
		
		static int set_bit(int val, int n)
		{
			// set val's n-th bit to 1
			return val | (1 << n);
		}
		
		static int clear_bit(int val, int n)
		{
			// set val's n-th bit to 0
			return val & (~(1 << n));
		}
		
		static int update_bit(int val, int n, int s)
		{
			// update val's n-th bit to s (s should be 1 or 0)
			return (val & (~(1 << n))) | (s << n);
		}
		
		static int toggle_bit(int val, int n)
		{
			// toggle val's n-th bit
			return val ^ (1 << n);
		}
		
		static int clear_bits_to_n(int val, int n)
		{
			// clear bits from top to n
			return val & ((1 << n) - 1);
		}
		
		static int clear_bits_from_n_1(int val, int n)
		{
			// clear bits from n - 1 to 0
			return val & (~((1 << n) - 1));
		}
		
	    static int modulus_power_of_2(int val, int n)
	    {
	    	// val % (2 power n)
	    	return val & ((1 << n) - 1);
	    }
		
		static bool is_even(int val)
		{
			// check whether val is even
			return (val & 1) == 0;
		}
		
		static bool is_odd(int val)
		{
			// check whether val is odd
			return (val & 1) == 1;
		}
		
		static int get_sign(int val)
		{
			// get val's sign
			return (val >> 31) & 1;
			// if >> is logic shift, we can omit & 1
			//return val >> 31;
		}
		
		static bool is_negative(int val)
		{
			// check whether val is negative
			// not so good ...
			return (val >> 31) != 0;
		}
		
		static bool is_power_of_2(int val)
		{
			// check whether val is power of 2
			//return (val & (val - 1)) == 0;
			return ((val & (val - 1)) == 0) && (val != 0);
		}
		
		static int floor_power_of_2(int val)
		{
			// calc power of 2 which <= val
			val |= (val >> 1);
			val |= (val >> 2);
			val |= (val >> 4);
			val |= (val >> 8);
			val |= (val >> 16);
			return val - (val >> 1);
		}
		
		static int ceil_power_of_2(int val)
		{
			// calc power of 2 which >= val
			val -= 1;
			val |= (val >> 1);
			val |= (val >> 2);
			val |= (val >> 4);
			val |= (val >> 8);
			val |= (val >> 16);
			val += 1;
			return val;
		}
		
		static int closest_power_of_2(int val)
		{
			var ceil = ceil_power_of_2(val);
			var floor = ceil >> 1; // var floor = floor_power_of_2(val);
			return val - floor < ceil - val ? floor : ceil;
		}
		
		static int min(int a, int b)
		{
			var mask = (a - b) >> 31;
			return (a & mask) | (b & ~mask);
		}
		
		static int max(int a, int b)
		{
			var mask = (a - b) >> 31;
			return (b & mask) | (a & ~mask);
		}
		
		static int clamp(int val, int min_val, int max_val)
		{
			return min(max(val, min_val), max_val);
		}
		
		static void swap(ref int a, ref int b)
		{
			a ^= b;
			b ^= a;
			a ^= b;
		}
		
		static int abs(int v)
		{
			var mask = v >> 31;
			return (v + mask) ^ mask;
		}
		
		static int if_c_then_a_else_b(int c, int a, int b)
		{
			// c <= 0 means false, > 0 means true
			return ((-c >> 31) & (a ^ b)) ^ b;
		}
		
		static int if_c_then_a_else_0(int c, int a)
		{
			// c <= 0 means false, > 0 means true
			return (-c >> 31) & a;
		}
		
		static uint revert_bits(uint val)
		{
			val = ((val & 0x55555555) << 1) | ((val & 0xAAAAAAAA) >> 1);
			val = ((val & 0x33333333) << 2) | ((val & 0xCCCCCCCC) >> 2);
		    val = ((val & 0x0F0F0F0F) << 4) | ((val & 0xF0F0F0F0) >> 4);
			val = ((val & 0x00FF00FF) << 8) | ((val & 0xFF00FF00) >> 8);
			val = ((val & 0x0000FFFF) << 16) | ((val & 0xFFFF0000) >> 16);
			return val;
	    }
		
		static uint revert_bytes(uint val)
		{
			val = ((val & 0x00FF00FF) << 8) | ((val & 0xFF00FF00) >> 8);
			val = ((val & 0x0000FFFF) << 16) | ((val & 0xFFFF0000) >> 16);
			return val;
		}
		
		static void Print(object val)
		{
			Console.WriteLine(val);
		}
		
		static void PrintHex(object val)
		{
			Console.WriteLine("{0:x}", val);
		}
		
		public static void Main(string[] args)
		{
			Print(multiply_2_power_n(1, 1)); // 2
			Print(divide_2_power_n(2, 1)); // 1
			Print(get_bit(1, 0)); // 1
			Print(set_bit(0, 0)); // 1
			Print(clear_bit(1, 0)); // 0
			Print(update_bit(1, 0, 0)); // 0
			Print(update_bit(1, 0, 1)); // 1
			Print(update_bit(1, 2, 1)); // 5
			Print(toggle_bit(1, 2)); // 5
			Print(toggle_bit(toggle_bit(1, 2), 2)); // 1
			Print(clear_bits_to_n(1, 1)); // 1
			Print(clear_bits_from_n_1(2, 1)); // 2
			Print(modulus_power_of_2(7, 3)); // 7
			Print(modulus_power_of_2(17, 3)); // 1
			Print(modulus_power_of_2(32, 3)); // 0
			Print(is_even(2)); // true
			Print(is_odd(2)); // false
			Print(get_sign(1)); // 0
			Print(get_sign(-1)); // 1
			Print(is_negative(1)); // false
			Print(is_negative(-1)); // true
			Print(is_power_of_2(2)); // true
			Print(is_power_of_2(3)); // false
			Print(is_power_of_2(0)); // false
			Print(floor_power_of_2(17)); // 16
			Print(ceil_power_of_2(17)); // 32
			Print(floor_power_of_2(16)); // 16
			Print(ceil_power_of_2(16)); // 16
			Print(closest_power_of_2(16)); // 16
			Print(closest_power_of_2(17)); // 16
			Print(closest_power_of_2(31)); // 32
			Print(min(13, 14)); // 13
			Print(max(13, 14)); // 14
			Print(max(13, 13)); // 13
			Print(clamp(13, 1, 5)); // 5
			Print(clamp(13, 15, 17)); // 15
			Print(clamp(13, 1, 17)); // 13
			
			int a = 13;
			int b = 17;
			swap(ref a, ref b);
			Print(a + " " + b); // 17 13
			
			Print(abs(13)); // 13
			Print(abs(-13)); // 13
			Print(if_c_then_a_else_b(0, 13, 17)); // 17
			Print(if_c_then_a_else_b(-1, 13, 17)); // 17
			Print(if_c_then_a_else_b(1, 13, 17)); // 13
			Print(if_c_then_a_else_0(0, 13)); // 0
			Print(if_c_then_a_else_0(-1, 13)); // 0
			Print(if_c_then_a_else_0(1, 13)); // 13
			
			PrintHex(revert_bits(0x12345678)); // 0x1e6a2c48
			PrintHex(revert_bytes(0x12345678)); // 0x78563412
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}