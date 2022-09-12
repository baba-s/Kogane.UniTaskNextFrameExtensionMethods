# Kogane UniTask Next Frame Extension Methods

UniTask.NextFrame を GameObject 型や Component 型の拡張メソッドで呼び出せるようにするパッケージ

## 使用例

```csharp
using System.Threading;
using Cysharp.Threading.Tasks;
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private readonly CancellationTokenSource m_cancellationTokenSource = new();

    private async UniTaskVoid Start()
    {
        await gameObject.NextFrame();
        await gameObject.NextFrame( m_cancellationTokenSource.Token );
        await this.NextFrame();
        await this.NextFrame( m_cancellationTokenSource.Token );
    }
}
```