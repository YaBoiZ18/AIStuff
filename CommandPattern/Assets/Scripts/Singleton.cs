using UnityEngine;

namespace Assets.Scripts
{
    public class  Singleton<T> : 
        MonoBehaviour where T : Component {
        
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Object.FindAnyObjectByType<T>();
                        

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// The Application.IsPlaying is used 
        /// so that the Unity Editor does not complain 
        /// about Destroying the object when in Edit Mode.
        /// </summary>
        public virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (Application.isPlaying)
                {
                    DestroyImmediate(gameObject);
                }
            }
        }
    }
}