/*
 * You are given an absolute path for a Unix-style file system, which always begins with a slash '/'. Your task is to transform this absolute path into its simplified canonical path.
 * The rules of a Unix-style file system are as follows:
 * 
 * A single period '.' represents the current directory.
 * A double period '..' represents the previous/parent directory.
 * Multiple consecutive slashes such as '//' and '///' are treated as a single slash '/'.
 * Any sequence of periods that does not match the rules above should be treated as a valid directory or file name. For example, '...' and '....' are valid directory or file names.
 * The simplified canonical path should follow these rules:
 * 
 * The path must start with a single slash '/'.
 * Directories within the path must be separated by exactly one slash '/'.
 * The path must not end with a slash '/', unless it is the root directory.
 * The path must not have any single or double periods ('.' and '..') used to denote current or parent directories.
 * Return the simplified canonical path.
 * 
 * Example 1:
 * Input: path = "/home/"
 * Output: "/home"
 * Explanation: The trailing slash should be removed.
 * 
 * Example 2:
 * Input: path = "/home//foo/"
 * Output: "/home/foo"
 * Explanation: Multiple consecutive slashes are replaced by a single one.
 * 
 * Example 3:
 * Input: path = "/home/user/Documents/../Pictures"
 * Output: "/home/user/Pictures"
 * Explanation: A double period ".." refers to the directory up a level (the parent directory).
 * 
 * Example 4:
 * Input: path = "/../"
 * Output: "/"
 * Explanation: Going one level up from the root directory is not possible.
 * 
 * Example 5:
 * Input: path = "/.../a/../b/c/../d/./"
 * Output: "/.../b/d"
 * Explanation: "..." is a valid name for a directory in this problem.
 * 
 * Constraints:
 * 1 <= path.length <= 3000
 * path consists of English letters, digits, period '.', slash '/' or '_'.
 * path is a valid absolute Unix path.
 * */
using System.Text;

// Companies: @Meta
namespace PreperationsTest.LeetCode.Medium.Strings
{
    [TestClass]
    public class _71_SimplifyPath
    {
        [TestMethod]
        public void Run()
        {
            string path = "/.../a/../b/c/../d/./";
            path = SimplifyPath(path);
        }

        /// <summary>
        /// TC - O(N), Split take O(n), Stack.Reverse() takes O(n), stringBuilder takes O(n)
        /// SC - O(N), stack uses O(n), string[] takes O(n), stringBuilder uses O(n)
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            // we need a stack to store the valid directories
            Stack<string> stack = new Stack<string>();

            // split the string based on '/' slash
            string[] components = path.Split('/');

            // iterate the comonents and apply rules
            foreach (string directory in components)
            {
                // '.' rule - continue
                if (directory == "." || directory == "")
                {
                    continue;
                    }

                // ".." parent directory, means we need to remove the top stack value
                else if (directory == "..")
                {
                    if (stack.Count != 0)
                    {
                        stack.Pop();
                    }
                }

                //for all other values, we consider it as a valid directory
                else
                {
                    stack.Push(directory);
                }
            }

            // Now we have valid directories in the stack,
            // Iterate and form a string by inserting '/' 
            StringBuilder sb = new StringBuilder();
            foreach (string component in stack.Reverse())
            {
                sb.Append('/' + component); 
            }

            return sb.Length > 0 ? sb.ToString() : "/";
        }

        /// <summary>
        /// SAME AS ABOVE BUT USING LIST
        /// TC - O(N), Split take O(n)
        /// SC - O(N), stack uses O(n), string[] takes O(n), stringBuilder uses O(n)
        /// </summary>
        /// <param name="path"></param>
        public string SimplifyPath_UsingList(string path)
        {
            // we need a  list or a stack to store the valid directories
            List<string> list = new List<string>();

            // split the string based on '/' slash
            string[] directories = path.Split('/');

            // iterate the comonents and apply rules
            foreach (string directory in directories)
            {
                // '.' rule - continue
                if (directory == "." || directory == "")
                {
                    continue;
                }

                // ".." parent directory, means we need to remove the top stack value
                else if (directory == "..")
                {
                    if (list.Count != 0)
                    {
                        list.RemoveAt(list.Count - 1);
                    }
                }

                //for all other values, we consider it as a valid directory
                else
                {
                    list.Add(directory);
                }
            }

            // If we use stack, we need to iterate from stack.Reverse() to get the directories
            return "/" + string.Join("/", list.ToArray());
        }
    }
}
