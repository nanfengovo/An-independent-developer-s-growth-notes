import type { EdgeEventsEmit, EdgeEventsOn, GraphEdge, VueFlowStore } from '../types'

export declare function useEdgeHooks(
  edge: GraphEdge,
  emits: VueFlowStore['emits'],
): {
  emit: EdgeEventsEmit
  on: EdgeEventsOn
}
