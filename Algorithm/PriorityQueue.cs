using System;
using System.Collections.Generic;

namespace Algorithm
{
    class PriorityQueue<T> where T : IComparable<T> // 우선순위 큐
    {
        List<T> _heap = new List<T>();

        // 새로운 값 추가 O(logN)
        public void Push(T data)
        {
            // 힙의 맨 끝에 새로운 데이터 삽입
            _heap.Add(data);

            int now = _heap.Count - 1;      // 현재 인덱스
            // 도장깨기 시작
            while (now > 0)
            {
                // 도장깨기 시도
                int next = (now - 1) / 2;   // 부모의 인덱스와 비교
                if (_heap[now].CompareTo(_heap[next]) < 0)
                    break;

                // 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치 이동
                now = next;
            }
        }

        // 가장 큰 값 꺼내오기 O(logN)
        public T Pop()
        {
            // 반환할 데이터 따로 저장
            T ret = _heap[0];

            // 마지막 데이터를 루트로 이동
            int lastIndex = _heap.Count - 1;
            _heap[0] = _heap[lastIndex];
            _heap.RemoveAt(lastIndex);
            lastIndex--;

            // 역으로 내려가는 도장깨기
            int now = 0;
            while (true)
            {
                int left = 2 * now + 1;
                int right = 2 * now + 2;

                int next = now;
                // 왼쪽 값이 현재 값보다 크면, 왼쪽으로 이동
                if (left <= lastIndex && _heap[left].CompareTo(_heap[next]) > 0)
                    next = left;
                // 오른쪽 값이 현재 값(왼쪽 이동 포함)보다 크면, 왼쪽으로 이동
                if (right <= lastIndex && _heap[right].CompareTo(_heap[next]) > 0)
                    next = right;

                // 왼쪽/오른쪽 모두 현재 값보다 작으면 종료
                if (next == now)
                    break;

                // 두 값을 교체
                T temp = _heap[now];
                _heap[now] = _heap[next];
                _heap[next] = temp;

                // 검사 위치 이동
                now = next;
            }

            return ret;
        }

        public int Count { get { return _heap.Count; } }
    }
}
