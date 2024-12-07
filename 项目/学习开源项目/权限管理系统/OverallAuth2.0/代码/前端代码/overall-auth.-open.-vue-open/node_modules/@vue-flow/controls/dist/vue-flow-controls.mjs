import { openBlock as t, createElementBlock as i, renderSlot as n, createElementVNode as v, defineComponent as Z, computed as f, createBlock as l, unref as c, withCtx as u, Fragment as O, createVNode as $, resolveDynamicComponent as d, createCommentVNode as r } from "vue";
import { PanelPosition as F, useVueFlow as P, Panel as A } from "@vue-flow/core";
const D = {
  name: "ControlButton",
  compatConfig: { MODE: 3 }
}, E = (o, e) => {
  const a = o.__vccOpts || o;
  for (const [h, m] of e)
    a[h] = m;
  return a;
}, N = { class: "vue-flow__controls-button" };
function L(o, e, a, h, m, p) {
  return t(), i("button", N, [
    n(o.$slots, "default")
  ]);
}
const w = /* @__PURE__ */ E(D, [["render", L]]), R = {
  xmlns: "http://www.w3.org/2000/svg",
  viewBox: "0 0 32 32"
}, S = /* @__PURE__ */ v("path", { d: "M32 18.133H18.133V32h-4.266V18.133H0v-4.266h13.867V0h4.266v13.867H32z" }, null, -1), U = [
  S
];
function j(o, e) {
  return t(), i("svg", R, U);
}
const q = { render: j }, G = {
  xmlns: "http://www.w3.org/2000/svg",
  viewBox: "0 0 32 5"
}, J = /* @__PURE__ */ v("path", { d: "M0 0h32v4.2H0z" }, null, -1), K = [
  J
];
function Q(o, e) {
  return t(), i("svg", G, K);
}
const T = { render: Q }, W = {
  xmlns: "http://www.w3.org/2000/svg",
  viewBox: "0 0 32 30"
}, X = /* @__PURE__ */ v("path", { d: "M3.692 4.63c0-.53.4-.938.939-.938h5.215V0H4.708C2.13 0 0 2.054 0 4.63v5.216h3.692V4.631zM27.354 0h-5.2v3.692h5.17c.53 0 .984.4.984.939v5.215H32V4.631A4.624 4.624 0 0 0 27.354 0zm.954 24.83c0 .532-.4.94-.939.94h-5.215v3.768h5.215c2.577 0 4.631-2.13 4.631-4.707v-5.139h-3.692v5.139zm-23.677.94a.919.919 0 0 1-.939-.94v-5.138H0v5.139c0 2.577 2.13 4.707 4.708 4.707h5.138V25.77H4.631z" }, null, -1), Y = [
  X
];
function oo(o, e) {
  return t(), i("svg", W, Y);
}
const to = { render: oo }, eo = {
  xmlns: "http://www.w3.org/2000/svg",
  viewBox: "0 0 25 32"
}, no = /* @__PURE__ */ v("path", { d: "M21.333 10.667H19.81V7.619C19.81 3.429 16.38 0 12.19 0 8 0 4.571 3.429 4.571 7.619v3.048H3.048A3.056 3.056 0 0 0 0 13.714v15.238A3.056 3.056 0 0 0 3.048 32h18.285a3.056 3.056 0 0 0 3.048-3.048V13.714a3.056 3.056 0 0 0-3.048-3.047zM12.19 24.533a3.056 3.056 0 0 1-3.047-3.047 3.056 3.056 0 0 1 3.047-3.048 3.056 3.056 0 0 1 3.048 3.048 3.056 3.056 0 0 1-3.048 3.047zm4.724-13.866H7.467V7.619c0-2.59 2.133-4.724 4.723-4.724 2.591 0 4.724 2.133 4.724 4.724v3.048z" }, null, -1), so = [
  no
];
function co(o, e) {
  return t(), i("svg", eo, so);
}
const lo = { render: co }, io = {
  xmlns: "http://www.w3.org/2000/svg",
  viewBox: "0 0 25 32"
}, ro = /* @__PURE__ */ v("path", { d: "M21.333 10.667H19.81V7.619C19.81 3.429 16.38 0 12.19 0c-4.114 1.828-1.37 2.133.305 2.438 1.676.305 4.42 2.59 4.42 5.181v3.048H3.047A3.056 3.056 0 0 0 0 13.714v15.238A3.056 3.056 0 0 0 3.048 32h18.285a3.056 3.056 0 0 0 3.048-3.048V13.714a3.056 3.056 0 0 0-3.048-3.047zM12.19 24.533a3.056 3.056 0 0 1-3.047-3.047 3.056 3.056 0 0 1 3.047-3.048 3.056 3.056 0 0 1 3.048 3.048 3.056 3.056 0 0 1-3.048 3.047z" }, null, -1), ao = [
  ro
];
function uo(o, e) {
  return t(), i("svg", io, ao);
}
const vo = { render: uo }, ho = {
  name: "Controls",
  compatConfig: { MODE: 3 }
}, fo = /* @__PURE__ */ Z({
  ...ho,
  props: {
    showZoom: { type: Boolean, default: !0 },
    showFitView: { type: Boolean, default: !0 },
    showInteractive: { type: Boolean, default: !0 },
    fitViewParams: null,
    position: { default: F.BottomLeft }
  },
  emits: ["zoomIn", "zoomOut", "fitView", "interactionChange"],
  setup(o, { emit: e }) {
    const {
      nodesDraggable: a,
      nodesConnectable: h,
      elementsSelectable: m,
      setInteractive: p,
      zoomIn: V,
      zoomOut: g,
      fitView: C,
      viewport: z,
      minZoom: k,
      maxZoom: H
    } = P(), _ = f(() => a.value || h.value || m.value), B = f(() => z.value.zoom <= k.value), y = f(() => z.value.zoom >= H.value);
    function I() {
      V(), e("zoomIn");
    }
    function M() {
      g(), e("zoomOut");
    }
    function x() {
      C(o.fitViewParams), e("fitView");
    }
    function b() {
      p(!_.value), e("interactionChange", !_.value);
    }
    return (s, mo) => (t(), l(c(A), {
      class: "vue-flow__controls",
      position: o.position
    }, {
      default: u(() => [
        n(s.$slots, "top"),
        o.showZoom ? (t(), i(O, { key: 0 }, [
          n(s.$slots, "control-zoom-in", {}, () => [
            $(w, {
              class: "vue-flow__controls-zoomin",
              disabled: c(y),
              onClick: I
            }, {
              default: u(() => [
                n(s.$slots, "icon-zoom-in", {}, () => [
                  (t(), l(d(c(q))))
                ])
              ]),
              _: 3
            }, 8, ["disabled"])
          ]),
          n(s.$slots, "control-zoom-out", {}, () => [
            $(w, {
              class: "vue-flow__controls-zoomout",
              disabled: c(B),
              onClick: M
            }, {
              default: u(() => [
                n(s.$slots, "icon-zoom-out", {}, () => [
                  (t(), l(d(c(T))))
                ])
              ]),
              _: 3
            }, 8, ["disabled"])
          ])
        ], 64)) : r("", !0),
        o.showFitView ? n(s.$slots, "control-fit-view", { key: 1 }, () => [
          $(w, {
            class: "vue-flow__controls-fitview",
            onClick: x
          }, {
            default: u(() => [
              n(s.$slots, "icon-fit-view", {}, () => [
                (t(), l(d(c(to))))
              ])
            ]),
            _: 3
          })
        ]) : r("", !0),
        o.showInteractive ? n(s.$slots, "control-interactive", { key: 2 }, () => [
          o.showInteractive ? (t(), l(w, {
            key: 0,
            class: "vue-flow__controls-interactive",
            onClick: b
          }, {
            default: u(() => [
              c(_) ? n(s.$slots, "icon-unlock", { key: 0 }, () => [
                (t(), l(d(c(vo))))
              ]) : r("", !0),
              c(_) ? r("", !0) : n(s.$slots, "icon-lock", { key: 1 }, () => [
                (t(), l(d(c(lo))))
              ])
            ]),
            _: 3
          })) : r("", !0)
        ]) : r("", !0),
        n(s.$slots, "default")
      ]),
      _: 3
    }, 8, ["position"]));
  }
});
export {
  w as ControlButton,
  fo as Controls
};
