using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Kogane
{
    public static class UniTaskNextFrameExtensionMethods
    {
        public static async UniTask NextFrame( this GameObject self )
        {
            await UniTask.NextFrame( self.GetCancellationTokenOnDestroy() );
        }

        public static async UniTask NextFrame( this Component self )
        {
            await self.gameObject.NextFrame();
        }

        public static async UniTask NextFrame
        (
            this GameObject   self,
            CancellationToken cancellationToken
        )
        {
            var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource
            (
                cancellationToken,
                self.GetCancellationTokenOnDestroy()
            );

            await UniTask.NextFrame( cancellationTokenSource.Token );
        }

        public static async UniTask NextFrame
        (
            this Component    self,
            CancellationToken cancellationToken
        )
        {
            await self.gameObject.NextFrame( cancellationToken );
        }
    }
}