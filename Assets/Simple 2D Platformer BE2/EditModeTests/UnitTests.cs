using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class UnitTests
    {
        [Test]
        public void PlayerFinishInitialize()
        {
            GameObject player = GameObject.Find("Player");
            Vector3 startPositionPlayer = new Vector3((float)-2.0, (float)0.5, (float)0.0);
            Vector3 startPositionFinish = new Vector3((float)61.6, (float)4.1, (float)0.0);
            Assert.AreEqual(player.transform.position, startPositionPlayer);
            foreach (Transform platform in GameObject.Find("Platforms").transform)
                foreach (Transform transform in platform)
                    if (transform.Find("Finish"))
                        Assert.AreEqual(transform.position, startPositionFinish);
        }
    }
}
