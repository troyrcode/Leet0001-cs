// 1. Two Sum
// Easy
// Given an array of integers nums and an integer target, 
// return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution, 
// and you may not use the same element twice.
// You can return the answer in any order.

// Example 1:
// Input: nums = [2,7,11,15], target = 9
// Output: [0,1]
// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

// Example 2:
// Input: nums = [3,2,4], target = 6
// Output: [1,2]

// Example 3:
// Input: nums = [3,3], target = 6
// Output: [0,1]

// Constraints:
//     2 <= nums.length <= 104
//     -109 <= nums[i] <= 109
//     -109 <= target <= 109
//     Only one valid answer exists.

// Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?

Console.WriteLine("1. Two Sum");


var solution = new Solution();
var result = solution.TwoSum([2,7,11,15], 9);
PrintResult(result);
result = solution.TwoSum([3,2,4], 6);
PrintResult(result);
result = solution.TwoSum([3,3], 6);
PrintResult(result);

void PrintResult(int[] result)
{
    Console.WriteLine($"[{result[0]} , {result[1]}]");
}

// O(n^2)
public class Solution2 {
    public int[] TwoSum(int[] nums, int target) 
    {
        var result = new int[2];  // should contain the 2 indices that add up to target

        // slow and simple way O(n^2)
        for(int i=0; i<nums.Length; i++){
            for(int j=0; j<nums.Length; j++)
            {
                if(i != j && nums[i] + nums[j] == target)  //constraint i != j
                {
                    result[0] = i;
                    result[1] = j;
                    return result;
                }
            }
        }
        return result;
    }
}

//less than O(n2) time complexity
public class Solution {
    public int[] TwoSum(int[] nums, int target) 
    {
        var result = new int[2];  // should contain the 2 indices that add up to target
        var diffHash = new Dictionary<int, int>(); //store diff, index

        // fast way using hash table containing differences
        diffHash.Add(target - nums[0], 0);
        for(int i=1; i<nums.Length; i++)
        {
            int diff = target - nums[i];
            if (diffHash.TryGetValue(target - diff, out int value))
            {
                result[0] = i;
                result[1] = value;
                return result;
            }
            diffHash.TryAdd(diff, i);
        }
        return result;
    }
}