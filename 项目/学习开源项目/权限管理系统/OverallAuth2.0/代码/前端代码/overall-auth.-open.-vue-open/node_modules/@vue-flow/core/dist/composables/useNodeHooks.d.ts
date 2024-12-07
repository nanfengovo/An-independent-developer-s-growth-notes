import type { GraphNode, NodeEventsEmit, NodeEventsOn, VueFlowStore } from '../types'

export declare function useNodeHooks(
  node: GraphNode,
  emits: VueFlowStore['emits'],
): {
  emit: NodeEventsEmit
  on: NodeEventsOn
}
