import type { KeyFilter, MaybeRefOrGetter } from '@vueuse/core'

export declare function isInputDOMNode(event: KeyboardEvent): boolean
/**
 * Reactive key press state
 *
 * @param keyFilter - Can be a boolean, a string or an array of strings. If it's a boolean, it will always return that value. If it's a string, it will return true if the key is pressed. If it's an array of strings, it will return true if any of the keys are pressed, or a combination is pressed (e.g. ['ctrl+a', 'ctrl+b'])
 * @param onChange - Callback function that will be called when the key state changes
 */
export declare function useKeyPress(
  keyFilter: MaybeRefOrGetter<KeyFilter | null>,
  onChange?: (keyPressed: boolean) => void,
): import('vue').Ref<boolean>
