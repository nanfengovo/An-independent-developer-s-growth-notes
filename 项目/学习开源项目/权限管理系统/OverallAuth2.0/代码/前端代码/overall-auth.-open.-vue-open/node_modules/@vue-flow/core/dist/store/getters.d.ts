import type { ComputedRef } from 'vue'
import type { ComputedGetters, State } from '../types'

export declare function useGetters(state: State, nodeIds: ComputedRef<string[]>, edgeIds: ComputedRef<string[]>): ComputedGetters
