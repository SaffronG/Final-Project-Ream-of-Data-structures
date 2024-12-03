namespace Dependencies.Dungeon
{
    public class Challenges {
        ChallengeNode? Head { get; set; }
        public Challenges(ChallengeNode? Head = null, params int[] nums) {
            PopulateChallenges(nums[nums.Length/2], nums);
        }

        private void PopulateChallenges(int middle, params int[] nums) {
            Insert(middle, Head);
            PopulateChallenges(nums[nums.Length/2], nums[0..(nums.Length/4)]); // LEFT -> MID
            PopulateChallenges(nums[(int)(nums.Length / (float).5)], nums[(nums.Length/2)..nums.Length]); // MID -> RIGHT
        }

        private bool Insert(int value, ChallengeNode? current) {
            if (Head is null) {
                Head = new ChallengeNode(value);
                return true;
            }
            else {
                if (current!.Left!.ChallengeRating > value) {
                    Insert(value, current.Right);
                }
                else {
                    Insert(value, current.Left);
                }
            }
            return false;
        }
    }
    public class ChallengeNode(int CR, ChallengeNode? Left = null, ChallengeNode? Right = null) {
        public int ChallengeRating { get; set; } = CR;
        public ChallengeNode? Left { get; set; } = Left;
        public ChallengeNode? Right { get; set; } = Right;
    }
}