import type { UseDragEvent } from './useDrag'

/**
 * This composable is for *internal* use only.
 */
export declare function useGetPointerPosition(): ({ sourceEvent }: UseDragEvent) => {
  x: number
  y: number
  xSnapped: number
  ySnapped: number
}
