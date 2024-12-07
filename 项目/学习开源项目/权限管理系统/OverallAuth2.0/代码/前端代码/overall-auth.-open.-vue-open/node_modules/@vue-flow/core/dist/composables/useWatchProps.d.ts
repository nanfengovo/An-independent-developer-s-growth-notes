import type { ToRefs } from 'vue'
import type { FlowProps, VueFlowStore } from '../types'

export declare function useWatchProps(
  models: ToRefs<Pick<FlowProps, 'nodes' | 'edges' | 'modelValue'>>,
  props: FlowProps,
  store: VueFlowStore,
): () => void
