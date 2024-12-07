type UseWindow = Window &
  typeof globalThis & {
    chrome?: any
  }
export declare function useWindow(): UseWindow
export {}
